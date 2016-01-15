using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.Presentation.WUI.Models.Question;

namespace WIPCream.Presentation.WUI.App_Helper.AutoMapper
{
    public class QuestionMapper
    {
        public static List<QuestionUIDTO> GetQuestionUIDTOList(List<QuestionDTO> QuestionList)
        {
            Mapper.CreateMap<List<QuestionDTO>, List<QuestionUIDTO>>();
            List<QuestionUIDTO> QuestionUIDTO = new List<QuestionUIDTO>();
            QuestionUIDTO model;
            foreach(var item in QuestionList)
            {
                Mapper.CreateMap<QuestionDTO, QuestionUIDTO>();
                model = Mapper.Map<QuestionUIDTO>(item);
                QuestionUIDTO.Add(model);
            }
            return QuestionUIDTO;
        }
        public static QuestionDTO GetQuestionDTO(QuestionUIDTO Question)
        {
            Mapper.CreateMap<QuestionUIDTO, QuestionDTO>();
            return Mapper.Map<QuestionDTO>(Question);
        }
        public static QuestionUIDTO GetQuestionUIDTO(QuestionDTO Question)
        {
            Mapper.CreateMap<QuestionDTO, QuestionUIDTO>();
            return Mapper.Map<QuestionUIDTO>(Question);
        }
    }
}
