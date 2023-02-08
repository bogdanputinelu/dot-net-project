import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  public hide = true;

  public registerForm = this.formBuilder.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    age: ['', Validators.required],
    userName: ['', Validators.required],
    email: ['', Validators.required],
    password: ['', Validators.required]
  })

  constructor(private readonly formBuilder: FormBuilder,
              private readonly router: Router,
              private readonly authService: AuthService) { }

  ngOnInit(): void {

  }
  sendForm() {
    this.authService.createUser(this.registerForm.value).subscribe(data => {
      this.router.navigate(['login']).then(() => window.location.reload());
    })
    this.getFormValidationErrors(['email']);
  }
  getFormValidationErrors(keys: any) {
    keys.forEach((key: any) => {
      const controlErrors = this.registerForm.get(key)?.errors;
      if (controlErrors != null) {
        alert(key + " has errors" + controlErrors);
      }
    });
  }

}
