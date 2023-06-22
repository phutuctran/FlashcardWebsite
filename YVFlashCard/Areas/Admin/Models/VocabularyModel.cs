using YVFlashCard.Service.Vocabularies.DTO;

namespace YVFlashCard.Areas.Admin.Models
{
	public class VocabularyModel : VocabularyDTO
	{
		public VocabularyModel() : base() { }
		public VocabularyModel(VocabularyDTO v) : base(v) { }	
	}
}
