import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Apartment } from '../../data/interfaces/apartment';

@Component({
  selector: 'app-apartments',
  templateUrl: './apartments.component.html',
  styleUrls: ['./apartments.component.css']
})
export class ApartmentsComponent implements OnInit {
  public apartmentFromApi: Apartment = { id: '', name: '', price: 0, numberOfRooms: 0, squareMeters: 0 };
  public title: string = "Apartments"
  private readonly apiUrl = environment.apiUrl;

  constructor(private readonly httpClient: HttpClient) { }

  ngOnInit(): void {
    let apartmentId = "129C064C-4218-4B8F-BD7F-08DADFDBFDB8";
    this.httpClient.get<Apartment>(`${this.apiUrl}Apartments/apartments/${apartmentId}`).subscribe((data) => {
      console.log(data);
      this.apartmentFromApi = data;
    });
  }

}
