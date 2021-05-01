import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorizationFailedComponent } from './authorization-failed.component';

describe('AuthorizationFailedComponent', () => {
  let component: AuthorizationFailedComponent;
  let fixture: ComponentFixture<AuthorizationFailedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthorizationFailedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthorizationFailedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
