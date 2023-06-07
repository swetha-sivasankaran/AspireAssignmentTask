using System.ComponentModel.DataAnnotations;
namespace Assignment.Contracts.DTO
{
    public class EmployeeDTO
    {

        public int EmpDetailsID	{ get; set; }
	    public string FirstName{ get; set; }	
	    public string LastName{ get; set; }
	    public DateTime DOB{ get; set; }     

		public int GenderRefId{ get; set; }
		
	   	  
        public string ContactNumber{get; set;}
	    public string? AlternateNumber{get; set;}
	    public string EmpEmailId{get; set;}
	    public string Address{get; set;}
	    public string City{get; set;}
 	    public string State{get; set;}
	    public string Country{get; set;}
	    public string? Zip{get; set;}
	    public string EmployeeNumber{get; set;}
	    public string EmpDesignation{get; set;}

		public int PracticeRefId{ get; set; }
	    
	    public DateTime DOJ{get; set;}
        public string EmpType{get; set;} 
	//	public string Gender{get; set;}   
		//public string Practice{get; set;}


        
    }
}