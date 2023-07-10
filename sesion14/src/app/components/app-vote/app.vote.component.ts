import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-vote',
  templateUrl: './app.vote.component.html'
})
export class VoteComponent {
  @Input() nombre = '';
  @Output() voted = new EventEmitter<boolean>();
  didVote = false;

  vote(agreed: boolean) {
    this.voted.emit(agreed);
    this.didVote = true;
  }
}