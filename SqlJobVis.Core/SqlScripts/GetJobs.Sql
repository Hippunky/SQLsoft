SELECT 
	J.job_id, 
	J.name, 
	J.enabled, 
	J.delete_level, 
	C.name AS category 
FROM
	dbo.sysjobs J WITH(NOLOCK)
	LEFT OUTER JOIN dbo.syscategories C WITH (NOLOCK) ON
		C.category_id = J.category_id;
                                
SELECT
	job_id,
	run_status, 
	run_date,
	run_time, 
	run_duration 
FROM
	dbo.sysjobhistory WITH (NOLOCK) WHERE step_id = 0 

EXEC dbo.sp_help_job