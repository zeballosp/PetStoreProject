import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ImageCarrouselComponent} from './components/image-carrousel/image-carrousel';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ImageCarrouselComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  protected readonly title = signal('Pet Store');
}
