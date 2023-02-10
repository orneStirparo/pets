import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PetFormPages } from './pets-form.pages';

describe('LoginComponent', () => {
  let component: PetFormPages;
  let fixture: ComponentFixture<PetFormPages>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PetFormPages ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PetFormPages);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
