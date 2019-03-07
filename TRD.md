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