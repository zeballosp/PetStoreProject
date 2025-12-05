import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-image-card',
  standalone: true,
  templateUrl: './image-card.html',
  styleUrls: ['./image-card.css']
})
export class ImageCardComponent implements OnChanges {
  @Input() imageUrl: string = '';
  @Input() label: string = '';

  ngOnChanges(changes: SimpleChanges): void {
  }
}
