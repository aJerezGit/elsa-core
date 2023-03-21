using System;
using Elsa.Activities.Http;
using System.Net;
using Elsa.Builders;
using Elsa.Services;
using Elsa.Activities.Timers.Activities;
using Elsa.Activities.Temporal;
using NodaTime;
using Elsa.Activities.Console;
using Elsa;

namespace elsa_net6
{
    public class HelloWorldWorkflow : IWorkflow
    {
        /*public void Build(IWorkflowBuilder builder)
        {
            builder
           .StartWith<TimerEvent>(activity => activity
               .Set(x => x.TimeoutExpression, context => TimeSpan.FromSeconds(5).ToString()))
           .Then<WriteHttpResponse>(x =>
           {
               x.Content = new Output<string>("Hello, World!");
               x.ContentType = "text/plain";
               x.StatusCode = HttpStatusCode.OK;
           });
        }*/

        //public class HeartbeatWorkflow : IWorkflow
        //{
          //  private readonly IClock _clock;
          //  public HelloWorldWorkflow(IClock clock) => _clock = clock;

        public void Build(IWorkflowBuilder builder) =>
            builder.HttpEndpoint("/hello-world").When(OutcomeNames.Done).WriteHttpResponse(HttpStatusCode.OK, "<h1>Hello World!</h1>", "text/html");
        //.Timer(Duration.FromSeconds(10))

        //WriteHttpResponse(HttpStatusCode.OK, "<h1>Hello World! </h1>", "text/html");
        /*.WithSupportedHttpCodes(new[] { 200, 400 }),
                activity =>
                {
                    activity.When("200").WriteLine("OK!");
                    activity.When("400").WriteLine("Missing some fields!");
                    activity.When("500").WriteLine("Server is sad :(");
                });*/

        //(context => $"Heartbeat at {_clock.GetCurrentInstant()}");
        //}
    }
}
