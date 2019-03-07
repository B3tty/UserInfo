# TRD

## Fonctional needs

### "Page" Endpoint

When on a page, I need to post data about the current page and the user currently viewing it. The data I want to send looks like this :

```json
{
    "user_id": "019mr8mf4r",
    "name": "Pricing Page",
    "timestamp": "2012-12-02T00:30:12.984Z"
}
```


### "User" Endpoint

I want to be able to fetch data bout a specific user id. The data I need to fetch is:

```json
{
    "user_id": "019mr8mf4r",
    "number_pages_viewed_the_last_7_days": 21,
    "time_spent_on_site_last_7_days": 18,
    "number_of_days_active_last_7 _days": 3,
    "most_viewed_page_last_7_days": "Blog: better B2B customer experience"
}
```

## Brainstorming on technical aspect

In the end, we want something like this :

* Page => Insert info in DB
* User => Get info from DB

We want to get info from the last 7 days. So we want to be able to filter the data by date. 

? Only want to get the last 7 days?
* we can clean the "deprecated" data
* we only need a timestamp with the day, not time

### Option 1 - "simple database" option

* when receiving info with page endpoint, storing in DB with timestamp
* when "user" is called, filter data according to timestamp and aggregate data

#### Pros
* Simple to implement
* Easy to change the interval if we need to: simply update the filter method, but everything is available in the db
#### Cons
* All the data is stored, so lots of data
* Fetching and filtering all the data might be long
  - we could index the data by day to make the filtering by date quicker, but then filtering on userId?
  - if we index by day, it's still okay for a wider interval, but we'd have to reindex if we want a narrower interval

### Option 2 - "cleaned database" option

* when receiving info with page endpoint, storing in DB with timestamp
* put a TTL of 7 days on data
* when "user" is called, aggregate data

#### Pros
* Simple to implement
* Less data to store
* No need to filter data since only useful data is in the db
#### Cons
* We lose the old data, so if we want to switch to a 1-month interval, at first we'll be missing data

### Option 3 - "event sourcing" option

* when receiving info with the page endpoint, send an event to a kafka bus (for example)
* the kafka bus listens to these events, and then aggregates them in a db
* we can have a daily (or nightly) job to clean the deprecated data from the db (replay events and have a job that does the opposite of the aggregating one)
* when "user" is called, aggregate data from db

#### Pros
* Scalable: if we want to change the interval, we'll simply have to create a one-time bach that replays events and fills (or empties) the db accordingly
* Once again the db only contains the needed info, so less data to store
#### Cons
* More difficult to implement, bigger TTM