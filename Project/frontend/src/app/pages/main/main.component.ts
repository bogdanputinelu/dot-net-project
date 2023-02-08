import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment.development';
import { Apartment } from '../../data/interfaces/apartment';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  public title: string = "Main component"
  //public apartmentFromApi1: Apartment = {
  //  id: '',
  //  name: '',
  //  price: 0,
  //  squareMeters: 0,
  //  numberOfRooms: 0
  //}
  //public apartmentFromApi2: Apartment = {
  //  id: '',
  //  name: '',
  //  price: 0,
  //  squareMeters: 0,
  //  numberOfRooms: 0
  //}
  //public apartmentFromApi3: Apartment = {
  //  id: '',
  //  name: '',
  //  price: 0,
  //  squareMeters: 0,
  //  numberOfRooms: 0
  //}

  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly httpClient: HttpClient, private readonly router: Router) { }

  ngOnInit(): void {
    //let apartmentId = "BDB4CBDC-3826-445E-15E2-08DB09EF7D73";

    ////get
    //this.httpClient.get<Apartment>(`${this.apiUrl}Apartments/apartments/${apartmentId}`).subscribe((data) => {
    //  console.log("First apartment from api", data);
    //  this.apartmentFromApi1 = data;
    //});

    ////post
    //let newApartment = {
    //  name: 'Ap 12',
    //  price: 15500,
    //  squareMeters: 70,
    //  numberOfRooms: 3
    //}

    //this.httpClient.post(`${this.apiUrl}Apartments/create`, newApartment).subscribe((data: any) => {
    //  console.log("Post response from api", data);
    //})

    ////put
    //let apartmentIdPatch = '2533B01B-0CAC-4AFB-15E0-08DB09EF7D73';
    //let apartmentPatch = {
    //  name: 'Ap 10',
    //  price: 14000,
    //  squareMeters: 60,
    //  numberOfRooms: 3
    //}

    //this.httpClient.put(`${this.apiUrl}Apartments/edit/${apartmentIdPatch}`, apartmentPatch).subscribe((data: any) => {
    //  console.log("Put response from api", data);
    //})

    ////delete
    //let deleteId = '2533B01B-0CAC-4AFB-15E0-08DB09EF7D73';
    //this.httpClient.delete<Apartment>(`${this.apiUrl}Apartments/delete/${deleteId}`).subscribe();

  }
  navigateTo() {
    this.router.navigate((['content']))
  }
}
