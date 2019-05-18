<Flags()> _
Public Enum FilterType
    Failed = 1
    LongRunning = 2
    Clashing = 4
    Inactive = 8
    Disabled = 16
End Enum

Public Enum SortType
    JobName
    TotalRunTime
    Frequency
    TimeClashing
    EarliestStartTime
End Enum

Public Enum DeleteLevel
    Never = 0
    OnSuccess = 1
    OnFailure = 2
    OnCompletion = 3
End Enum

Public Enum FreqType
    Once = 1
    Daily = 4
    Weekly = 8
    Monthly = 16
    MonthlyFreqInterval = 32
    OnAgentStart = 64
    OnIdle = 128
End Enum

Public Enum FreqSubdayType
    SpecifiedTime = 1
    Seconds = 2
    Minutes = 4
    Hours = 8
End Enum

Public Enum FreqRelativeInterval
    None = 0
    First = 1
    Second = 2
    Third = 4
    Fourth = 8
    Last = 16
End Enum

Public Enum RunStatus
    Failed = 0
    Succeeded = 1
    Retried = 2
    Canceled = 3
    InProgress = 4
End Enum
