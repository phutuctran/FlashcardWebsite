using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels.Models;

namespace YVFlashCard.Service.Vocabularies.DTO
{
    public class VocabularyDTO
    {
        public int WordID { get; set; }
        public string WordText { get; set; }
        public string Mean { get; set; }
        public string SpeechPart { get; set; }
        public int? ThemeID { get; set; }
        public int? level { get; set; }
        public byte[] IllustrationImg { get; set; }
        public string Author { get; set; }
        public List<int?> SynonymsList { get; set; }

        public VocabularyDTO()
        {
            SynonymsList = new List<int?>();
        }
        public VocabularyDTO(VocabularyDTO vob)
        {
            SetVocabularyDTO(vob);
			SynonymsList = new List<int?>();
		}

        public void SetVocabularyDTO(VocabularyDTO vob)
        {
            WordID = vob.WordID;
            WordText = vob.WordText;
            Mean = vob.Mean;
            SpeechPart = vob.SpeechPart;
            ThemeID = vob.ThemeID;
            level = vob.level;
            IllustrationImg = vob.IllustrationImg;
            Author = vob.Author;
        }
		public VocabularyDTO(Dictionary vob)
		{
            this.WordID = vob.WordId;
            this.WordText = vob.WordText;
			this.Mean = vob.Mean;
			this.SpeechPart = vob.SpeechPart;
            this.ThemeID = vob.ThemeId;
            this.level = vob.Level;
			this.IllustrationImg = vob.IllustrationImg;
			this.Author = vob.Author;
			SynonymsList = new List<int?>();
		}

	}
}
