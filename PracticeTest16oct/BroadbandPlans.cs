using System;
using System.Collections.Generic;

interface IBroadbandPlan
{
    int GetBroadbandPlanAmount();
}
class Black : IBroadbandPlan
{
    private readonly bool _isSubscriptionValid;
    private readonly int _discountPercentage;
    private const int PlanAmount = 3000;

    public Black(bool isSubscriptionValid, int discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 50)
        {
            throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 50.");
        }
        _isSubscriptionValid = isSubscriptionValid;
        _discountPercentage = discountPercentage;
    }

    public int GetBroadbandPlanAmount()
    {
        if (_isSubscriptionValid)
        {
            return PlanAmount - (PlanAmount * _discountPercentage / 100);
        }
        return PlanAmount;
    }
}

class Gold : IBroadbandPlan
{
    private readonly bool _isSubscriptionValid;
    private readonly int _discountPercentage;
    private const int PlanAmount = 1500;

    public Gold(bool isSubscriptionValid, int discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 30)
        {
            throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 30.");
        }
        _isSubscriptionValid = isSubscriptionValid;
        _discountPercentage = discountPercentage;
    }

    public int GetBroadbandPlanAmount()
    {
        if (_isSubscriptionValid)
        {
            return PlanAmount - (PlanAmount * _discountPercentage / 100);
        }
        return PlanAmount;
    }
}

class SubscribePlan
{
    private readonly IList<IBroadbandPlan> _broadbandPlans;

    public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
    {
        _broadbandPlans = broadbandPlans ?? throw new ArgumentNullException(nameof(broadbandPlans), "Broadband plans list cannot be null.");
    }

    public IList<Tuple<string, int>> GetSubscriptionPlan()
    {
        var subscriptionPlanList = new List<Tuple<string, int>>();

        foreach (var plan in _broadbandPlans)
        {
            string planType = plan.GetType().Name;
            int planAmount = plan.GetBroadbandPlanAmount();
            subscriptionPlanList.Add(new Tuple<string, int>(planType, planAmount));
        }

        return subscriptionPlanList;
    }
}

class BroadbandPlans
{
    static void Main(string[] args)
    {
        var plans = new List<IBroadbandPlan>
        {
            new Black(true, 50),
            new Black(false, 10),
            new Gold(true, 30),
            new Black(true, 20),
            new Gold(false, 20)
        };

        var subscriptionPlans = new SubscribePlan(plans);
        var result = subscriptionPlans.GetSubscriptionPlan();

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Item1}, {item.Item2}");
        }
    }
}