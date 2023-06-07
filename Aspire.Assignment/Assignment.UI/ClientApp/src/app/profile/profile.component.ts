import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../_models/employee';
import { ReferenceTbl } from '../_models/referenceTbl';
import { EmployeeService } from '../_services/employee.service';
import { TokenResponse } from '../_models/user';
import { AccountService } from '../_services/account.service';


@Component({
  
  templateUrl: './profile.component.html',
})
export class ProfileComponent implements OnInit {
  data: any;
  id: any ;
  employee: any ;
  employees: Employee[] = [];
  BreakError={};
  references:ReferenceTbl[]= [];

  user: TokenResponse | null;


  
    constructor(private employeeService: EmployeeService,
      private activatedRoute: ActivatedRoute , 
      private accountService: AccountService) {
        this.user = this.accountService.userValue;

       }
  
  
    ngOnInit(): void {

      //GetByID
      this.activatedRoute.params.subscribe(data => {
        this.id = data.id
      })

      if(this.user?.userName==this.employee.firstName)
      {
      this.employeeService.getAllReference()
      .subscribe(references => {this.references = references; 
      console.log(references)});

      this.employeeService.getById(this.id).subscribe(data => {
        this.employee= data;  
        console.log(data);
        
      this.employeeService.getAll()
        .subscribe(employees => {this.employees = employees
       
        this.employees.forEach((empl)=>
        {
          console.log(empl)
          this.references.forEach((ref)=>{    
            console.log(ref)
       
            if(empl.empDetailsID==this.employee.empDetailsID)
            {
            if(ref.referenceId==empl.genderRefId)
              {
                this.employee.gender=ref.title;
                console.log(ref.title)
                console.log(this.employee.gender)               
              }
              else if(ref.referenceId==empl.practiceRefId)
              {
                this.employee.practice=ref.title
                console.log(ref.title)

                console.log(this.employee.practice)
                

              }
            }

      })
    });
  });
});
} 
    }

           
    }
                
