import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../_services/employee.service';
import { Employee } from '../_models/employee';
import { ReferenceTbl } from '../_models/referenceTbl';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AddEmployee } from '../_models/addEmployee';
import { AlertService } from '../_services/alert.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {
  employees: Employee[] = [];
  references:ReferenceTbl[]= [];
  data!: any;
  EmployeeForm!: FormGroup;
  empObj: Employee[]=[];
  addemployeeobj: AddEmployee = new AddEmployee();

  

  constructor( 
    private formbuilder: FormBuilder,
    private employeeService: EmployeeService,
    private alertService: AlertService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.EmployeeForm = this.formbuilder.group({
      employeeDetailId:[''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dob: ['', Validators.required],
      genderRefId: ['', Validators.required],
      contactNumber: ['', Validators.required],
      alternateNumber: ['', Validators.required],
      empEmailId:[],
      address:[],
      city:[],
      state:[],
      country:[],
      zip:[],
      employeeNumber:[],
      empDesignation:[],
      practiceRefId:[],
      doj:[],
      empType:[],
    })



    // to fetch reference table value.
    this.employeeService.getAllReference()
    .subscribe(references => {this.references = references; 
    console.log(references)});
    // to get fetch all employee detail along with gender and practice value

    this.employeeService.getAll()
    .subscribe(employees => {this.employees = employees
    // for each to iterate geneder and practice value

              this.employees.forEach((empl)=>{
                // console.log(empl)
                this.references.forEach((ref)=>{
                  console.log(ref)
                
              if(ref.referenceId==empl.genderRefId )
                {
                  empl.gender=ref.title;
                }
                else if(ref.referenceId==empl.practiceRefId)
                {
                  empl.practice=ref.title

                }
                
                })
                })
              });   

                
  }


  deleteEmployee(item: any) {
      if (confirm('Are you sure to delete record?'))
        this.employeeService.delete(item.empDetailsID)
        .subscribe({
          next: () => {
              this.alertService.success('Employee detail deleted successfully', { keepAfterRouteChange: true });
              this.router.navigateByUrl('/empl');
              //for page refresh after delete
              window.location.reload();
          },
          error: (error: any) => {
              this.alertService.error(error);
          }

        });


        
    }

    getEmployeeDetails() {
      this.employeeService.getAll().subscribe((data: any[]) => {
        this.data = data;
      });
    }
}


