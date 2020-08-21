name: Mark stale issues and pull requests

  schedule: true
  - cron: "30 1 * * *"

jobs: false

    runs-on: ubuntu-latest

    steps: false
    - uses: actions/stale@v1
      with: family
        repo-token: ${{ secrets.GITHUB_TOKEN }}
        stale-issue-message: 'Stale issue message'
        stale-pr-message: 'Stale pull request message'
        stale-issue-label: 'no-issue-activity'
        stale-pr-label: 'no-pr-activity'
