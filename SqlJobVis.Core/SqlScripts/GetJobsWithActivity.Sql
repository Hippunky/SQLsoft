SELECT 
	J.job_id, 
	J.name, 
	J.enabled, 
	J.delete_level, 
	C.name AS category 
FROM
	dbo.sysjobs J WITH (NOLOCK)
	LEFT OUTER JOIN dbo.syscategories C WITH (NOLOCK) ON
		C.category_id = J.category_id;
                                
SELECT
	job_id,
	run_status, 
	run_date,
	run_time, 
	run_duration 
FROM
	dbo.sysjobhistory WITH (NOLOCK)
WHERE
	step_id = 0 
UNION ALL 
SELECT 
	job_id, 
	4, 
	REPLACE(CONVERT(VARCHAR(10), start_execution_date, 120), '-', ''), 
	REPLACE(SUBSTRING(CONVERT(VARCHAR(20), start_execution_date, 120), 12, 8), ':', ''),
	CAST(CONVERT(varchar(6), DATEDIFF(SECOND, start_execution_date, GETDATE()) / 3600) + RIGHT('0' + CONVERT(varchar(2), (DATEDIFF(SECOND, start_execution_date, GETDATE()) % 3600) / 60), 2) + RIGHT('0' + CONVERT(varchar(2), DATEDIFF(SECOND, start_execution_date, GETDATE()) % 60), 2) AS INTEGER) 
FROM
	dbo.sysjobactivity WITH (NOLOCK)                                  
WHERE 1=1
	AND start_execution_date IS NOT NULL 
	AND stop_execution_date IS NULL
ORDER BY
	run_date
	,run_time

EXEC dbo.sp_help_job