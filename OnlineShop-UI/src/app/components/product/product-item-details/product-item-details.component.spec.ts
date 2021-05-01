import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductItemDetailsComponent } from './product-item-details.component';

describe('ProductItemDetailsComponent', () => {
  let component: ProductItemDetailsComponent;
  let fixture: ComponentFixture<ProductItemDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductItemDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductItemDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
