var cached_greyhound_response = null;
var parsed_greyhound_response = null;

// Requests GreyHound Race event info from web server and updates info
function request_greyhoundrace_info() {
    $.ajax({
        url: "/api/greyhoundrace",
    })
  .done(function (data) {
      
      if (cached_greyhound_response == data) {
          return; // no new data, exit function
      }
      cached_greyhound_response = data;
      
      // ParseJSON
      parsed_greyhound_response = $.parseJSON(data);
      console.log(parsed_greyhound_response);

      $(".events_container").html(""); // clear container

      for (key in parsed_greyhound_response) {
          // add event wrapper
          $(".events_container").append("<div class='event' id='event_" + parsed_greyhound_response[key].ID + "' ><p></p> <div class='entries'></div> </div>");

          // add event info
          $(".events_container #event_" + parsed_greyhound_response[key].ID + " p").append("<ul>");
          $(".events_container #event_" + parsed_greyhound_response[key].ID + " p").append("<li>EventNumber: " + parsed_greyhound_response[key].EventNumber + "</li>");
          $(".events_container #event_" + parsed_greyhound_response[key].ID + " p").append("<li>EventTime: " + Date(parsed_greyhound_response[key].EventTime) + "</li>");
          $(".events_container #event_" + parsed_greyhound_response[key].ID + " p").append("<li>FinishTime: " + Date(parsed_greyhound_response[key].FinishTime) + "</li>");
          $(".events_container #event_" + parsed_greyhound_response[key].ID + " p").append("<li>Distance: " + parsed_greyhound_response[key].Distance + "</li>");
          $(".events_container #event_" + parsed_greyhound_response[key].ID + " p").append("<li>Name: " + parsed_greyhound_response[key].Name + "</li>");
          $(".events_container #event_" + parsed_greyhound_response[key].ID + " p").append("</ul>");

          // add event entries
          if (parsed_greyhound_response[key].Entries.length > 0) {
              $(".events_container #event_" + parsed_greyhound_response[key].ID + " .entries").append("<table class='entry_table' id='entry_table_" + parsed_greyhound_response[key].ID + "'><thead><tr><th>Name</th><th>OddsDecimal</th><tbody></tbody></table>");
              for (entry_key in parsed_greyhound_response[key].Entries) {
                  var entry_info = "<tr><td>" + parsed_greyhound_response[key].Entries[entry_key].Name + "</td><td>" + parsed_greyhound_response[key].Entries[entry_key].OddsDecimal + "</td></tr>";
                  $(".events_container table#entry_table_" + parsed_greyhound_response[key].ID +" tbody").append(entry_info);
                  //console.log(":EID:" + ".events_container #event_" + parsed_greyhound_response[key].ID + " .entries table tbody");
              }
          } else {
              $(".events_container #event_" + parsed_greyhound_response[key].ID + " .entries").append("No entries for this event");
          }
      }

      $("table").DataTable();

  });

}

request_greyhoundrace_info(); // dont wait for delay from setInterval
var request_greyhoundrace_info_timer_id = setInterval(function () { request_greyhoundrace_info(); }, 2000)

