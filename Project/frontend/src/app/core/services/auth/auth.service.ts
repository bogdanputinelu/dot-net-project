import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { ApiService } from '../api/api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly route = "Users/";

  constructor(private readonly apiService: ApiService) { }

  login(loginBody: any): Observable<any> {
    let logBody = {
      "userName": "string",
      "password": loginBody['password'],
      "email": loginBody['email'],
      "age": 0,
      "firstName": "string",
      "lastName": "string"
    }
    console.log(logBody);
    return this.apiService.post<any>(`${this.route}authenticate`, logBody).pipe(
      tap((response: any) => {
        
        if (response) {
          localStorage.setItem('token', response.token);
          localStorage.setItem('userId', response.id);
        }
      })
    )
  }

  createUser(createUserBody: any): Observable<any> {
    return this.apiService.post<any>(`${this.route}create-user`, createUserBody);
  }

  isLoggedIn(): boolean {
    let token = localStorage.getItem('token');
    return token != null;
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
  }
}
