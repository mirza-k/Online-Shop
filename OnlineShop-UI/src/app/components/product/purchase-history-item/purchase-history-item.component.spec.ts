import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseHistoryItemComponent } from './purchase-history-item.component';

describe('PurchaseHistoryItemComponent', () => {
  let component: PurchaseHistoryItemComponent;
  let fixture: ComponentFixture<PurchaseHistoryItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchaseHistoryItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseHistoryItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
