using DBModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.Interfaces;
using YVFlashCard.Service.ServiceImpl.ThemeService.DTO;
using YVFlashCard.Service.Types;
using YVFlashCard.Service.Vocabularies.DTO;

namespace YVFlashCard.Service.Vocabularies
{
	public class DictionaryServiceImpl : IDictionaryWordService
	{
		public Task<bool> CreateNewVocabularyAsync(VocabularyDTO vocabulary)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteVocabularyAsync(VocabularyDTO vocabulary)
		{
			throw new NotImplementedException();
		}


		public async Task<List<VocabularyDTO>> GetVocabularyAsync(IGetVocabularyStrategy getVocabulary)
		{
			var dbs = new YVFlashCardContext();
			var words = await getVocabulary.GetVocabularyAsync();
			List<VocabularyDTO> result = new List<VocabularyDTO>();
			foreach (var word in words)
			{
				VocabularyDTO vob = new VocabularyDTO(word);
				var synonyms = await dbs.Synonyms.Where(u => u.WordId1 == vob.WordID || u.WordId2 == vob.WordID).ToListAsync();
				synonyms.ForEach(u => vob.SynonymsList.Add(u.WordId1 == vob.WordID ? u.WordId2 : u.WordId1));
				result.Add(vob);
			}
			return result;
		}
	}

	public class GetVocabularyTake : IGetVocabularyStrategy
	{
		string _keySearch;
		int _count;
		public GetVocabularyTake(int count, string keySearch)
		{
			_keySearch = string.IsNullOrEmpty(keySearch) ? "" : keySearch.Trim();
			_count = count == 0 ? SettingTypes.DEFAULT_COUNT : count;
		}

		public async Task<List<Dictionary>> GetVocabularyAsync()
		{
			var dbs = new YVFlashCardContext();
			return await dbs.Dictionary.Where(u => u.WordText.Contains(_keySearch) || u.Mean.Contains(_keySearch)).Take(_count).ToListAsync();
		}
	}
	public class GetVocabularyByAdmin : IGetVocabularyStrategy
	{
		string _keySearch;
		int _count;
		public GetVocabularyByAdmin(int count = 0, string keySearch = "")
		{
			_keySearch = string.IsNullOrEmpty(keySearch) ? "" : keySearch.Trim();
			_count = count == 0 ? SettingTypes.DEFAULT_COUNT : count;
		}
		public async Task<List<Dictionary>> GetVocabularyAsync()
		{
			var dbs = new YVFlashCardContext();
			return await dbs.Dictionary.Where(u => u.Role == "A" && (u.WordText.Contains(_keySearch) || u.Mean.Contains(_keySearch))).Take(_count).ToListAsync();
		}


	}
	public class GetVocabularyByUser : IGetVocabularyStrategy
	{
		string _keySearch;
		int _count;
		string _role;
		string _username;
		public GetVocabularyByUser(string username, string role, int count, string keySearch)
		{
			_keySearch = string.IsNullOrEmpty(keySearch) ? "" : keySearch.Trim();
			_count = count == 0 ? SettingTypes.DEFAULT_COUNT : count;
			_username = username;
			_role = role;
		}
		public async Task<List<Dictionary>> GetVocabularyAsync()
		{
			var dbs = new YVFlashCardContext();
			return await dbs.Dictionary.Where(u => u.Author == _username && u.Role == _role && (u.WordText.Contains(_keySearch) || u.Mean.Contains(_keySearch))).Take(_count).ToListAsync();
		}

	}
}
