import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AlertService } from '../_services/alert.service';
import { UserService } from '../_services/user.service';


@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form!: FormGroup;
    id?: number;
    title!: string;
    loading = false;
    submitting = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private userService: UserService,
        private alertService: AlertService
    ) { }

    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.form = this.formBuilder.group({
            name: ['', Validators.required],
            description: ['', Validators.required],
            price: ['', Validators.required],
            type: ['', Validators.required],
            developer: ['', Validators.required],
        });

        this.title = 'Add App';
        if (this.id) {
            // edit mode
            this.title = 'Edit App';
            this.loading = true;
            this.userService.getById(this.id)
                .pipe(first())
                .subscribe(x => {
                    this.form.patchValue(x);
                    this.loading = false;
                });
        }
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.submitting = true;
        this.userService.post(this.form.value)
            .subscribe({
                next: () => {
                    this.alertService.success('App detail saved', { keepAfterRouteChange: true });
                    this.router.navigateByUrl('/apps');
                },
                error: (error: any) => {
                    this.alertService.error(error);
                    this.submitting = false;
                }
            })
    }

}