import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReasignarComponent } from './reasignar.component';

describe('ReasignarComponent', () => {
  let component: ReasignarComponent;
  let fixture: ComponentFixture<ReasignarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReasignarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReasignarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
