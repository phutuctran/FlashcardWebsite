using DBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YVFlashCard.Service.Vocabularies.DTO;

namespace YVFlashCard.Service.Interfaces
{
	public interface IDictionaryService
	{
		Task<Dictionary?> AuthenticateAsync(string wordID);

		Task<List<VocabularyDTO>> GetAllVocabularyAsync();

        Task<List<VocabularyDTO>> GetVocabularyByTopAsync(int count);
    }
}
