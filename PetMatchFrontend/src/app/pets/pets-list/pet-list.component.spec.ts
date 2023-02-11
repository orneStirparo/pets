import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PetListComponent } from './pet-list.component';

describe('PetsComponent', () => {
  let component: PetListComponent;
  let fixture: ComponentFixture<PetListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PetListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PetListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
