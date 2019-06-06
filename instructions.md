# Work sample - Back-end Engineer

## Project description

## Why this project

The objective is to make this a good and fun way to discover how it would look like working together on a data engineering project.

##Instructions

Please do as much or as little as we want. Expectations is to spend between 2 and 4 hours of work to document a TRD (1-2 pages) and build a functional POC.

## How to make this project fun and effective

Here are some tips:

- This documentation is a starting point and we’ve deliberately left gaps. So feel free to ask clarifying questions and communicate regularly the same way you would do in a team.
- Iterate often and fast. Throw your notes in a TRD document. The idea of using a TRD is to explore quickly different technical design ideas and communicate on them. Using proper english or good fonts don’t matter.

## Product requirements

### Endpoints

Create a API service with 2 API routes.

#### Call to send page view events

Send page view information to update the behavioral stats for a user.

`POST /v1/page`

Body of the POST:

```json
{
  "user_id": "019mr8mf4r",
  "name": "Pricing Page",
  "timestamp": "2012-12-02T00:30:12.984Z"
}
```

#### Call to get a summary of the behavioral profile
Return the behavioral profile of a user.

`GET v1/user/:userid`

Returns

```json
{
  "user_id": "019mr8mf4r",
  "number_pages_viewed_the_last_7_days": 21,
  "time_spent_on_site_last_7_days": 18,
  "number_of_days_active_last_7 _days": 3,
  "most_viewed_page_last_7_days": "Blog: better B2B customer experience"
}
```

#### Bonus: Call to delete the profile of a user (GDPR)

Delete all data about a user, ie. the raw events data if stored, and the aggregated profile data. This is to be in compliance with GDPR requirements.

`DELETE v1/user/:userid`
