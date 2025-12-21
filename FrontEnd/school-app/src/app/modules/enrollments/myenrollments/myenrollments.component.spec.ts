import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyenrollmentsComponent } from './myenrollments.component';

describe('MyenrollmentsComponent', () => {
  let component: MyenrollmentsComponent;
  let fixture: ComponentFixture<MyenrollmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MyenrollmentsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyenrollmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
