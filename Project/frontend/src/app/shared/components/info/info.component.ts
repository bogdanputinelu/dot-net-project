import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApartmentService } from '../../../core/services/apartment/apartment.service';
import { Apartment } from '../../../data/interfaces/apartment';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit{
  public apartmentFromApi: Apartment = { id: '', name: '', price: 0, squareMeters: 0, numberOfRooms: 0 }
  public apartmentsFromApi: Apartment[] = [];

  constructor(private readonly apartmentService: ApartmentService, private readonly router: Router) { }

  ngOnInit(): void {
    let apartmentId = "E37D7852-2116-46C3-15E1-08DB09EF7D73";
    this.apartmentService.getApartmentWithQueryParams(apartmentId).subscribe(data => {
      console.log('getApartmentWithQueryParams', data);
      this.apartmentFromApi = data;
    });

    this.apartmentService.getApartmentWithQueryParamsFilter(apartmentId).subscribe(data => {
      this.apartmentFromApi = data;
    });

    this.apartmentService.getAllApartments().subscribe(data => {
      this.apartmentsFromApi = data;
      console.log(data);
      console.log(this.apartmentsFromApi);
    });

    this.apartmentService.response.subscribe((data: any) => {
      console.log("response from BehaviorSubject", data);
      this.apartmentFromApi = data;
    })
  }

  navigateToApartment(id: string) {
    this.router.navigate((['content',id]))
  }

}
