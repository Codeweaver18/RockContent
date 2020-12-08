Assumption:
****************************
some of the Assumption i have made during implementation are as follows.
**************************************************************************
-This implementation is solely for testing and will never be production ready
-i Assumed All other security features as in line with Software system design will be in place.


Resources Details and credentials (this credentials will be invalid two weeks from now)
******************************************************************************************
-Elastic Search:https://search-rocketcontent-vyubczoegxbpw7j6e4wuiin72i.us-east-1.es.amazonaws.com
-Kibana:https://search-rocketcontent-vyubczoegxbpw7j6e4wuiin72i.us-east-1.es.amazonaws.com/_plugin/kibana/app/home
-DockerImage repositoryname:codeweaver/rockcontentapi:dev
-AWS RDS Database:rockcontent.co4w2pitps4s.us-east-1.rds.amazonaws.com

Tools Used
*****************
-Database: MSSQL (AWS RDS Database)
-ORM: EFCore.
-Documentation: Swagger UI
-Error Logging: Serilog, ElasticSearch and Grafana {application error logging: ideal for centralized Logging}
-Runtime: .NetCore 
-IDE: Visual studio
-Frameworks: Nunit, .netCore WebApi


Database Structure
**********************
Table: PostLikes
****************
Fields:
*********
Id => unique id for each of the likes (this is database generated)
PostId => Id of the Post to be liked
UserIp => Ip address of the client/user accessing the application
BrowserAgent =>The Browser or the user agent the client is using to access the application
IsLike => likes response (bolean: False/True)



starting Application
***********************
-clone repository from Github
-open solution with visual studio
-click on run to build and run application in debug mode.
-navigate to application base http://server-address:port/swagger
-select individual endpoint to test and populate the expected details

Bonus challenge
************************************************************************************************************************
{
•	How can you improve the feature to make it scale to millions of users and perform without issues? Created 
•	A million concurrent users clicking the button at the same time.
•	A million concurrent users requesting the article's like count at the same time
}

Answer: to solve the above challenge, i will recomment the following.
********************************************************************
-setup and a kubernetes clusters in aws EKS.
-push application as docker image to dockerhub
-create Kubernetes services sets of type loadbalancer with the docker image repository to create the necessary pods in the deployment
-specify the required number of replicas for the deploments.

The Result
***************
-setting up the application in a kubernetes clusters and creating replicas of deployments makes it highly available as several nodes and application instances are available to serve request
-it also improves performance as more nodes are available to hande the request for much users as possible
-selecting a service set of type Loadbalance automatically balance clients request across available nodes and pods
-Generally, application becomes more resilient and highly available. 

Other Options
****************
-other suggestion to substitute might me inline-memory like reddis for caching of request and response? (this might affect the actual number of likes as per caching can keep stale data based on configuration)
-A combination of A queue, subscriber and publisher architecture can be used to push request to cluster of Microservices.

************************************************************************************************************
Recommendation
***************
-in a real world scenario where we have load balancers and other sort of gateways, this current solution might not be
effective as the userIP mostly is a gateway ip and is possible u have more than one user using same gateway and trying to
access the application. in the case one user has liked a post and another user wants to like the same most, it will be denied
as the userip in the db will be the gateway ip. to solve this problem, the application needs to be refactored to get the value 
of the "X-Forwarded-For" key from the client htttp request header. this will be the value of the actual client sending the request not the gateway

-to also further enforce this kind of restriction, i suggest implementation of some authentication module
like identity sever, simple membership  with a basic username and password. this will help and reduce implementation overhead as 
a user can be simply barned from liking a single post more than one.

