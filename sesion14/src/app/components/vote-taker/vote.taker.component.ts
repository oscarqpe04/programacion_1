import { Component } from '@angular/core';

@Component({
  selector: 'app-vote-taker',
  templateUrl: './vote.taker.component.html'
})
export class VoteTakerComponent {
  agreed = 0;
  disagreed = 0;
  newVoter = "";
  voters = ['Oscar', 'Juan', 'Jose', 'Maria'];

  onVoted(agreed: boolean) {
    if (agreed) {
      this.agreed++;
    } else {
      this.disagreed++;
    }
  }

  addVoter() {
    if (this.newVoter.trim() != "") {
        this.voters.push(this.newVoter);
        this.newVoter = "";
    }
  }
}