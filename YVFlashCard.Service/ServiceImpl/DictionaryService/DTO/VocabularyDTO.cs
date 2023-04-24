using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YVFlashCard.Service.Vocabularies.DTO
{
    public class VocabularyDTO
    {
        public int WordID { get; set; }
        public string WordText { get; set; }
        public string Mean { get; set; }
        public string SpeechPart { get; set; }
        public int ThemeID { get; set; }
        public int level { get; set; }
        public byte[] IllustrationImg { get; set; }
        public string Author { get; set; }

        public VocabularyDTO() { }
        public VocabularyDTO(VocabularyDTO vob)
        {
            SetVocabularyDTO(vob);
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

    }
}
