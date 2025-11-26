import { Directive, HostListener, HostBinding } from '@angular/core';

@Directive({
  selector: '[appHoverEffect]'
})
export class HoverEffectDirective {
  @HostBinding('style.border') border: string = 'none';

  @HostListener('mouseenter') onMouseEnter() {
    this.border = '2px solid blue';
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.border = 'none';
  }
}
