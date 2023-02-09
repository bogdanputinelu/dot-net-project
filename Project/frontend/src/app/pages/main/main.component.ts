import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment.development';
import { AuthService } from '../../core/services/auth/auth.service';
import { Apartment } from '../../data/interfaces/apartment';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  public title: string = "Main component"

  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly httpClient: HttpClient,
              private readonly router: Router,
              private readonly authService: AuthService) { }

  ngOnInit(): void {

  }
  navigateTo() {
    this.router.navigate((['content']))
  }
  logout() {
    this.authService.logout();
    this.router.navigate(['main']).then(() => window.location.reload());
  }
}
