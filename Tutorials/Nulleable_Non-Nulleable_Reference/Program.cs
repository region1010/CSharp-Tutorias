using BIBLIOTECA;

namespace  Nulleable_Non_Nulleable_Reference;

public class  SurveryQuestion{

    public static void Main(){
        
        var  surveyRun  =  new  SurveyRun();
        surveyRun.AddQuestion(QuestionType.YesNo, "Has your code ever throw a NullReferenceException?");
        surveyRun.AddQuestion(new SurveyQuestion(QuestionType.Number, "How many times (to the nearest 100) has that happended?"));
        surveyRun.AddQuestion(QuestionType.Text, "What is your favorite color?");
        surveyRun.PerformSurvey(50);
    
        foreach(var  participant  in surveyRun.AllParticipants){
        
            Console.WriteLine($"Participant: {participant.Id}:");
            if(participant.AnsweredSurvey){
            
                for(int i = 0;  i<surveyRun.Questions.Count; i++){
                
                    var  answer  =  participant.Answer(i);
                    Console.WriteLine($"\t{surveyRun.GetQuestion(i).QuestionText}  :  {answer}");
                
                }
            
            }
            else{
            
                Console.WriteLine("\tNo responses");
            
            }
        
        }
    }

}