import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent implements OnInit {
  options = { autoHide: true, scrollbarMinSize: 100 };

  constructor() { }

  ngOnInit(): void {
  }

}
