import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApartmentContentComponent } from './apartment-content.component';

describe('ApartmentContentComponent', () => {
  let component: ApartmentContentComponent;
  let fixture: ComponentFixture<ApartmentContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApartmentContentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApartmentContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
