import { Component, OnInit } from '@angular/core';
import { PetService } from '../../services/pet.service';
import { ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common'; // <-- import this
import { Pet } from '../../models/pet';
import { ImageCardComponent } from '../../components/image-card/image-card';

@Component({
  selector: 'app-image-carrousel',
  imports: [ImageCardComponent, CommonModule],
  standalone: true,
  templateUrl: './image-carrousel.html',
  styleUrl: './image-carrousel.css',
})
export class ImageCarrouselComponent implements OnInit {
  pets: Pet[] = [];

  constructor(private petService: PetService, private cdr: ChangeDetectorRef) {}

ngOnInit(): void {
  this.petService.getPets().subscribe({
    next: (data) => {
      this.pets = data;
      this.cdr.detectChanges(); // <-- force update
    },
    error: (err) => console.error('Error fetching pets', err)
  });
}
}
