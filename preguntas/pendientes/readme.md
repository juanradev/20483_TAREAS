### QUESTION 211 

##### Sintaxis PerformanceCounterType

(correspondía a Juanra)

You are developing a method named CreateCounters that will create performance counters for an application.

The method includes the following code. (Line numbers are included for reference only.)



```c#

void CreateCounters()
{
	if (!PerformanceCounterCategory.Existis("Contoso"))
	{
		var counters = new CounterCreationDataCollection();
		var ccdCounter1 = new CounterCreationDataCollection
		{
			CounterName ="Counter1";
			CounterType = PerfomanceCounterType.SampleFraction;
		}
		counters.Add (ccdCounter1);
		var ccdCounter2 = new CounterCreationData;
		{
			CounterName ="Counter2";
		}
		counters.Add (ccdCounter2);
		PerformanceCounterCategory.create("Contoso","Help string, PerformanceCounterCategory.MultiInstance, counters);
	}
}
````

Referencia:
https://docs.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2012/06tc147t(v=vs.110)?redirectedfrom=MSDN