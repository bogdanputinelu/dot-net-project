import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../../core/services/apartment/apartment.service';
import { Apartment } from '../../data/interfaces/apartment';

@Component({
  selector: 'app-apartment-content',
  templateUrl: './apartment-content.component.html',
  styleUrls: ['./apartment-content.component.css']
})
export class ApartmentContentComponent implements OnInit{
  public apartmentFromApi: Apartment = { id: '', name: '', price: 0, squareMeters: 0, numberOfRooms: 0 };
  public dataPassedInRoute = "";

  constructor(private readonly route: ActivatedRoute, private readonly apartmentService: ApartmentService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      console.log(params);
      this.dataPassedInRoute = params['id'];
    });

    this.apartmentService.getApartmentWithQueryParams(this.dataPassedInRoute).subscribe(data => {
      this.apartmentFromApi = data;
    })
  }

}
