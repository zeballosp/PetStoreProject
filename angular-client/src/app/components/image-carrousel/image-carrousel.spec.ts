import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageCarrousel } from './image-carrousel';

describe('ImageCarrousel', () => {
  let component: ImageCarrousel;
  let fixture: ComponentFixture<ImageCarrousel>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ImageCarrousel]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ImageCarrousel);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
