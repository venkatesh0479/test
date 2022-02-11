node{
    stage ('Checkout') {
        checkout([$class: 'SubversionSCM', 
        additionalCredentials: [], 
        excludedCommitMessages: '',
        excludedRegions: '', 
        excludedRevprop: '', 
        excludedUsers: '', 
        filterChangelog: false, 
        ignoreDirPropChanges: false, 
        includedRegions: '', 
        locations: [[cancelProcessOnExternalsFail: true, 
        credentialsId: 'e0680d74-a5eb-40e5-9dfd-f0290bd30ad9', 
        depthOption: 'infinity', 
        ignoreExternalsOption: true, 
        local: '.', 
        remote: 'https://crsvn/iss-interiors-tools/CommonServices/Logging/src']], 
        quietOperation: true, workspaceUpdater: [$class: 'UpdateUpdater']])
	}
    stage ('Build') {
        bat 'cd'
        dir('AppLogger') {
         bat 'cd'
         bat 'dotnet build App.Logger.csproj --configuration Release'
        }   
	}
	stage ('Test') {
        echo 'To create UT'
		dir('AppLoggerUnitTestCore') {
         bat 'cd'
		 bat 'dotnet test --logger trx'
		 mstest testResultsFile:"**/*.trx", keepLongStdio: true
        } 
	}
	stage ('Publish'){
	     bat 'cd'
	     dir('AppLogger\\bin\\Release') {
	         def allJob = env.JOB_NAME.tokenize('/') as String[];
             def projectName = allJob[0];
             echo projectName
	        archiveArtifacts artifacts: '*.nupkg', followSymlinks: false, fingerprint: true;
	        copyArtifacts(projectName: projectName, target: 'h:\\LocalNuget');
	     }
	    bat 'cd'
	}
}