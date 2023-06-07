import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AlertService } from '../_services/alert.service';
import { EmployeeService } from '../_services/employee.service';
import { AddEmployee } from '../_models/addEmployee';


@Component({ templateUrl: 'addeditemployee.component.html' })
export class AddeditemployeeComponent  implements OnInit {
  EmployeeForm!: FormGroup;
    id?: number;
    title!: string;
    loading = false;
    submitting = false;
    submitted = false;
    addemployeeobj: AddEmployee = new AddEmployee();
    genderdata!: any;
    practicedata!: any;
    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private employeeService: EmployeeService,
        private alertService: AlertService
    ) { }

    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.EmployeeForm = this.formBuilder.group({
            employeeDetailId:[''],
          firstName: ['', Validators.required],
          lastName: ['', Validators.required],
          dob: ['', Validators.required],
          genderRefId: ['', Validators.required],
          contactNumber: ['', Validators.required],
          alternateNumber: ['',],
          email:['', Validators.required],
          address:['', Validators.required],
          city:['',Validators.required],
          state:['', Validators.required],
          country:['', Validators.required],
          zip:['', ],
          employeeNumber:['', Validators.required],
          empDesignation:['', Validators.required],
          practiceRefId:['', Validators.required],
          doj:['', Validators.required],
          empType:['', Validators.required],
        });

        this.title = 'Add Employee';
        if (this.id) {
            // edit mode
            this.title = 'Edit-Employee';
            this.loading = true;
            this.employeeService.getById(this.id)
                .pipe(first())
                .subscribe(x => {
                    this.EmployeeForm.patchValue(x);
                    this.loading = false;
                });
        }

    // to fetch reference table value for drop down
    
        this.getReference()
    }

    // convenience getter for easy access to form fields
    get f() { return this.EmployeeForm.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.EmployeeForm.invalid) {
            return;
        }

        this.submitting = true;

        this.addemployeeobj.firstName = this.EmployeeForm.value.firstName;
        this.addemployeeobj.lastName = this.EmployeeForm.value.lastName;
        this.addemployeeobj.dob = this.EmployeeForm.value.dob;
        this.addemployeeobj.genderRefId = Number(this.EmployeeForm.value.genderRefId);
        this.addemployeeobj.contactNumber = this.EmployeeForm.value.contactNumber;
        this.addemployeeobj.alternateNumber = this.EmployeeForm.value.alternateNumber;
        this.addemployeeobj.email = this.EmployeeForm.value.email;
        this.addemployeeobj.address = this.EmployeeForm.value.address;
        this.addemployeeobj.city = this.EmployeeForm.value.city;
        this.addemployeeobj.state = this.EmployeeForm.value.state;
        this.addemployeeobj.country = this.EmployeeForm.value.country;
        this.addemployeeobj.zip = this.EmployeeForm.value.zip;
        this.addemployeeobj.employeeNumber = this.EmployeeForm.value.employeeNumber;
        this.addemployeeobj.empDesignation = this.EmployeeForm.value.empDesignation;
        this.addemployeeobj.practiceRefId = Number(this.EmployeeForm.value.practiceRefId);
        this.addemployeeobj.doj = this.EmployeeForm.value.doj;
        this.addemployeeobj.empType = this.EmployeeForm.value.empType;
        console.log(this.addemployeeobj)
       
        this.employeeService.post(this.addemployeeobj)
            .subscribe({
                next: () => {
                    this.alertService.success('Employee detail saved', { keepAfterRouteChange: true });
                    this.router.navigateByUrl('/empl');
                    // console.log(this.EmployeeForm)

                },
                error: (error: any) => {
                    this.alertService.error(error);
                    this.submitting = false;
                }


            })
    }

    getReference()
 {
  this.employeeService.getAllReference().subscribe((data: any[]) => {

    this.genderdata = data;
    this.practicedata= data;

  });
 }

}