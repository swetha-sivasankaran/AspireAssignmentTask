import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../_services/employee.service';
import { Employee } from '../_models/employee';
import { ReferenceTbl } from '../_models/referenceTbl';
import { ActivatedRoute } from '@angular/router';

@Component({
  
  templateUrl: './employeeById.component.html',
})
export class EmployeeBYIDComponent implements OnInit {
  data: any;
  id: any ;
  employee: any ;
  employees: Employee[] = [];
  BreakError={};
  references:ReferenceTbl[]= [];
  
    constructor(private employeeService: EmployeeService,private activatedRoute: ActivatedRoute ) { }
  
  
    ngOnInit(): void {

      this.activatedRoute.params.subscribe(data => {
        this.id = data.id
      })
      // to fetch reference table value.

      this.employeeService.getAllReference()
      .subscribe(references => {this.references = references; 
      console.log(references)});

      // to fetch employee record by Id, 

      this.employeeService.getById(this.id).subscribe(data => {
      this.employee= data;  
      console.log(data);
      // to get fetch all employee detail along with gender and practice value

      this.employeeService.getAll()
      .subscribe(employees => {this.employees = employees
      // for each to iterate geneder and practice value

        this.employees.forEach((empl)=>
        {
          console.log(empl)
          this.references.forEach((ref)=>{    
            // console.log(ref)
           if(empl.empDetailsID==this.employee.empDetailsID)
           {
            if(ref.referenceId==empl.genderRefId)
              {
                this.employee.gender=ref.title;
                // console.log(ref.title)
                // console.log(this.employee.gender)               
              }

              else if(ref.referenceId==empl.practiceRefId)
              {
                this.employee.practice=ref.title
                // console.log(ref.title)
                // console.log(this.employee.practice)
                

              }
            }
      })
    });
  });
});
    }
          
  }
