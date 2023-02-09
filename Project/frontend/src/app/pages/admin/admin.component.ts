import { Component } from '@angular/core';
import { UserService } from '../../core/services/user/user.service';
import { User } from '../../data/interfaces/user';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  public usersFromApi: User[] = []

  constructor(private readonly userService: UserService) { }

  getUsers() {
    this.userService.getUsers().subscribe(data => {
      this.usersFromApi = data;
    });
  }

  ngOnInit(): void {
    this.getUsers();
  }
}
