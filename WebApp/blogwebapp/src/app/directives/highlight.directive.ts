import { Directive, HostBinding, Input } from '@angular/core';

@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective {
  @Input('appHighlight') highlightColor: string = 'yellow'; // Input to set default highlight color

  @HostBinding('style.backgroundColor')
    backgroundColor!: string;

  ngOnInit() {
    this.backgroundColor = this.highlightColor; // Set initial background color
  }
}
