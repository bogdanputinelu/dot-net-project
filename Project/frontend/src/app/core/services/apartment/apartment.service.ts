import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { ApiService } from '../api/api.service';

@Injectable({
  providedIn: 'root'
})
export class ApartmentService {
  private readonly route = 'Apartments/';
  private responseSource = new BehaviorSubject<object>({});
  public response = this.responseSource.asObservable();

  constructor(private readonly apiService: ApiService) { }

  getApartmentWithQueryParams(Id = {}) {
    return this.apiService.get(this.route + 'apartments/' + Id);
  }

  getApartmentWithQueryParamsFilter(Id = {}) {
    return this.apiService.get(this.route + 'apartments/' + Id).pipe(map(x => {
      console.log("data from api inside service", x);
      this.responseSource.next(x);
      return x;
    }));
  }

}
