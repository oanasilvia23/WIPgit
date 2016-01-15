using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.DataGateway.DAL2.Services.QuestionEntity;

namespace WIPCream.BusinessGateway.Logic.Services.Question
{
    public class QuestionBusinessService:IQuestionBusinessService
    {
        private IQuestionService questionService;
        private Questions questionModel;

        public QuestionBusinessService()
        {
            questionService = new QuestionService();
        }
        public WIPCream2 getDB()
        {
            return questionService.GetDB();
        }
        public string RegisterQuestion(QuestionDTO model)
        {
            String transactionMessage = null;
            Transform_Questions_QuestionsDTO(model);
            transactionMessage = questionService.CreateEntity(questionModel);
            return transactionMessage;
        }
        public string Delete(int id)
        {
            String transactionMessage = null;
            transactionMessage = questionService.DeleteEntity(id);
            return transactionMessage;
        }
        public string Update(QuestionDTO question)
        {
            String transactionmessage = null;
            Transform_Questions_QuestionsDTO(question);
            transactionmessage = questionService.UpdateEntity(questionModel);
            return transactionmessage;
        }
        public List<QuestionDTO> RetrieveAll()
        {
            List<QuestionDTO> QuestionModel = new List<QuestionDTO>();
            List<Questions> Questions = questionService.RetrieveAll();
            Mapper.CreateMap<Questions, QuestionDTO>();
            QuestionDTO model;
            for(int i = 0; i< Questions.Count(); i++)
            {
                model = Mapper.Map<QuestionDTO>(Questions[i]);
                QuestionModel.Add(model);
            }
            return QuestionModel;
        }
        public QuestionDTO FindById(int id)
        {
            QuestionDTO model = new QuestionDTO();
            questionModel = questionService.Find(id);

            Mapper.CreateMap<Questions, QuestionDTO>();
            model = Mapper.Map<QuestionDTO>(questionModel);
            return model;
            
        }
        public void Transform_Questions_QuestionsDTO(QuestionDTO model)
        {
            Mapper.CreateMap<QuestionDTO, Questions>();
            questionModel = Mapper.Map<Questions>(model);
        }
        public void Dispose()
        {
            questionService.Dispose();
        }
    }
}
