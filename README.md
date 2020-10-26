# CarListAppForEmiratesAuction

I have used two approaches to get the car list.

Approach 1:
	 I have used 3 layed architecture such as Model,View,Controller. The controller is user to retrieve information from the API. 
	 View will display the required formatted output. Model with have the data structure properties.
         
	Here I have got the api response at serverside.I have used httpclient to communicate with the API.
	First I have displayed only 10 rows and then with LoadMore option I have got 2nd 10 rows.
	Here I have also other functionalities such as Refresh list,Filter List,Auto Refresh and Load More Data. 
	As per the requirement I have displayed the data in English and Arabic.
	I have used Bootstrap for navigation and jquery for other functionalities.
  <img>
  
  </img>

Approach 2:
         Here I have got the API response from clientSide.
	 I have used AJAX Jquery method to communicate with the API.
	 Displayed the results in HTML using Jquery binding 


I personaly feel Serverside communcation with API is better as it saves time by using LINQ.
