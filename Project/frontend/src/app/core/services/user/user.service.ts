import { Injectable } from '@angular/core';
import { ApiService } from '../api/api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly route = "Users/"

  constructor(private readonly apiService: ApiService) { }

  getUsers() {
    return this.apiService.get(this.route + "user");
  }
}
