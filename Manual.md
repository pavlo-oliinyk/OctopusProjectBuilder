﻿## Table of contents

1. [YamlDeploymentActionTemplate](#YamlDeploymentActionTemplate)
2. [YamlDeploymentStepTemplate](#YamlDeploymentStepTemplate)
3. [YamlProjectTemplate](#YamlProjectTemplate)
4. [YamlTemplateParameter](#YamlTemplateParameter)
5. [YamlTemplateReference](#YamlTemplateReference)
6. [YamlTemplates](#YamlTemplates)
7. [YamlDeploymentAction](#YamlDeploymentAction)
8. [YamlDeploymentProcess](#YamlDeploymentProcess)
9. [YamlDeploymentStep](#YamlDeploymentStep)
10. [YamlLibraryVariableSet](#YamlLibraryVariableSet)
11. [YamlLifecycle](#YamlLifecycle)
12. [YamlNamedElement](#YamlNamedElement)
13. [YamlOctopusModel](#YamlOctopusModel)
14. [YamlPhase](#YamlPhase)
15. [YamlProject](#YamlProject)
16. [YamlProjectGroup](#YamlProjectGroup)
17. [YamlPropertyValue](#YamlPropertyValue)
18. [YamlRetentionPolicy](#YamlRetentionPolicy)
19. [YamlVariable](#YamlVariable)
20. [YamlVariablePrompt](#YamlVariablePrompt)
21. [YamlVariableScope](#YamlVariableScope)

To start with model root type, please see: [YamlOctopusModel](#YamlOctopusModel)
## Model description

### <a name="YamlDeploymentActionTemplate"></a>1. YamlDeploymentActionTemplate

Deployment Step Action Template model definition.

|Property|Type|Description|
|--------|----|:----------|
|**TemplateName**|String|Unique template name. Default value: **null**. |
|**TemplateParameters**|String\[\]|List of template parameters, where accepted names should consist of alphanumeric characters and/or underscores. If template is not parameterized, the list should be left empty or undefined. Default value: **null**. |
|**Name**|String|Unique name. Default value: **null**. |
|**UseTemplate**|[YamlTemplateReference](#YamlTemplateReference)|Indicates that the resource is template based. Default value: **null**. |
|**ActionType**|String|Action type. Default value: **null**. |
|**Properties**|[YamlPropertyValue](#YamlPropertyValue)\[\]|Action properties. Default value: **null**. |

### <a name="YamlDeploymentStepTemplate"></a>2. YamlDeploymentStepTemplate

Deployment Step Template model definition.

|Property|Type|Description|
|--------|----|:----------|
|**TemplateName**|String|Unique template name. Default value: **null**. |
|**TemplateParameters**|String\[\]|List of template parameters, where accepted names should consist of alphanumeric characters and/or underscores. If template is not parameterized, the list should be left empty or undefined. Default value: **null**. |
|**Name**|String|Unique step name. Default value: **null**. |
|**UseTemplate**|[YamlTemplateReference](#YamlTemplateReference)|Indicates that the resource is template based. Default value: **null**. |
|**StartTrigger**|StepStartTrigger|Step start trigger. Possible values: **StartAfterPrevious**, **StartWithPrevious**. Default value: **StartAfterPrevious**. |
|**RequiresPackagesToBeAcquired**|Boolean|Wait for packages to be downloaded before running. Default value: **False**. |
|**Condition**|StepCondition|Step run condition. Possible values: **Success**, **Failure**, **Always**. Default value: **Success**. |
|**Actions**|[YamlDeploymentAction](#YamlDeploymentAction)\[\]|List of actions that are executed with this step. Default value: **null**. |
|**Properties**|[YamlPropertyValue](#YamlPropertyValue)\[\]|List of step additional properties. Default value: **null**. |

### <a name="YamlProjectTemplate"></a>3. YamlProjectTemplate

Project Template model definition.

|Property|Type|Description|
|--------|----|:----------|
|**TemplateName**|String|Unique template name. Default value: **null**. |
|**TemplateParameters**|String\[\]|List of template parameters, where accepted names should consist of alphanumeric characters and/or underscores. If template is not parameterized, the list should be left empty or undefined. Default value: **null**. |
|**Name**|String|Unique name. It can be used in other models to refer to this item. Default value: **null**. |
|**RenamedFrom**|String|Indicates that resource should be renamed. If specified, the upload process will try first to find resource with actual **Name** and update it. If not found it would try to find one with **RenamedFrom** name and update it, including rename to actual name. Only if none of the resources are found, a new one will be created. Default value: **null**. |
|**UseTemplate**|[YamlTemplateReference](#YamlTemplateReference)|Indicates that the resource is template based. Default value: **null**. |
|**Description**|String|Project description. Default value: **null**. |
|**LifecycleRef**|String|Lifecycle reference. Default value: **null**. |
|**ProjectGroupRef**|String|Project Group reference. Default value: **null**. |
|**IncludedLibraryVariableSetRefs**|String\[\]|References of Library Variable Sets that should be included in the project. Default value: **null**. |
|**IsDisabled**|Boolean|Disable a project to prevent releases or deployments from being created. Default value: **False**. |
|**AutoCreateRelease**|Boolean| Default value: **False**. |
|**DefaultToSkipIfAlreadyInstalled**|Boolean|Skips package deployment and installation if it is already installed. Default value: **False**. |
|**DeploymentProcess**|[YamlDeploymentProcess](#YamlDeploymentProcess)|Deployment process definition. Default value: **null**. |
|**Variables**|[YamlVariable](#YamlVariable)\[\]|Project variables. Default value: **null**. |

### <a name="YamlTemplateParameter"></a>4. YamlTemplateParameter

Template Parameter definition.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Parameter name. Default value: **null**. |
|**Value**|String|Parameter value. Default value: **null**. |

### <a name="YamlTemplateReference"></a>5. YamlTemplateReference

Template reference definition.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|The template name that given resource bases on. Default value: **null**. |
|**Parameters**|[YamlTemplateParameter](#YamlTemplateParameter)\[\]|The list of template parameters. The specified list has to correspond to the parameter list in template definition. Default value: **null**. |

### <a name="YamlTemplates"></a>6. YamlTemplates

Templates model definition.

The templating mechanism allows to simplify the model definitions and speed-up the process of defining them, by extracting the common model structure into the templates and later applying them to the models.

#### Specifying template values and applying it to the model
The model template allows to define values of all the properties that are defined in model.
The model definition itself can refer to the template, but it also can have own specification of the properties.
When the resource is being instantiated, the template would be used to provide the default values of the properties, that would be then customized with model definition.

#### Model property override
The model definition can override the default template value. It happens when both, template and model have defined the property value.
The property value resolution is implemented in a following way:

* if model have defined the value, it is being used,
* if model does not have defined property value (it is null), then template value is used.

Please note, that properties of value type (like int, bool etc.) would never be null, so they cannot be templated.
Please also note that properties of collection type (arrays, dictionaries) cannot be partially overridden. If model would contain a definition of such properties, the template property value would be ignored.

#### Parameterized templates
It is possible to parameterize templates with a list of parameters (consisting of alphanumeric and/or underscore characters).
The parameters can be used in property values defined in the template (at any tree level, including inner models, dictionary values, etc.), but they can be only applied to **string** type properties.
They are referenced with `${paramName}` syntax. It is possible to escape the `$` character with `\` if string like should not be updated: `\${this_is_not_a_param}`.

Example:
Assuming that we have parameters: 
* packageId=My_project
* packageVersion='1.2.3.4'

the property value `"${packageId} ver ${packageVersion}"` would be updated to `"My_project ver 1.2.3.4"`

|Property|Type|Description|
|--------|----|:----------|
|**DeploymentActions**|[YamlDeploymentActionTemplate](#YamlDeploymentActionTemplate)\[\]|List of Deployment Step Action templates Default value: **null**. |
|**DeploymentSteps**|[YamlDeploymentStepTemplate](#YamlDeploymentStepTemplate)\[\]|List of Deployment Step templates Default value: **null**. |
|**Projects**|[YamlProjectTemplate](#YamlProjectTemplate)\[\]|List of Project templates Default value: **null**. |

### <a name="YamlDeploymentAction"></a>7. YamlDeploymentAction

Project step deployment action definition.
Because Octopus Action definitions are generic (based on ActionType and list of properties), the easiest way to check how to define new actions is to model them first in Octopus and then use OctopusProjectBuilder.exe to download them to yaml files.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Unique name. Default value: **null**. |
|**UseTemplate**|[YamlTemplateReference](#YamlTemplateReference)|Indicates that the resource is template based. Default value: **null**. |
|**ActionType**|String|Action type. Default value: **null**. |
|**Properties**|[YamlPropertyValue](#YamlPropertyValue)\[\]|Action properties. Default value: **null**. |

### <a name="YamlDeploymentProcess"></a>8. YamlDeploymentProcess

Project deployment process definition.

|Property|Type|Description|
|--------|----|:----------|
|**Steps**|[YamlDeploymentStep](#YamlDeploymentStep)\[\]|List of steps to execute. Default value: **null**. |

### <a name="YamlDeploymentStep"></a>9. YamlDeploymentStep

Project Deployment Step model definition.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Unique step name. Default value: **null**. |
|**UseTemplate**|[YamlTemplateReference](#YamlTemplateReference)|Indicates that the resource is template based. Default value: **null**. |
|**StartTrigger**|StepStartTrigger|Step start trigger. Possible values: **StartAfterPrevious**, **StartWithPrevious**. Default value: **StartAfterPrevious**. |
|**RequiresPackagesToBeAcquired**|Boolean|Wait for packages to be downloaded before running. Default value: **False**. |
|**Condition**|StepCondition|Step run condition. Possible values: **Success**, **Failure**, **Always**. Default value: **Success**. |
|**Actions**|[YamlDeploymentAction](#YamlDeploymentAction)\[\]|List of actions that are executed with this step. Default value: **null**. |
|**Properties**|[YamlPropertyValue](#YamlPropertyValue)\[\]|List of step additional properties. Default value: **null**. |

### <a name="YamlLibraryVariableSet"></a>10. YamlLibraryVariableSet

Library Variable Set model definition allowing to define library variable sets and script modules.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Unique name. It can be used in other models to refer to this item. Default value: **null**. |
|**RenamedFrom**|String|Indicates that resource should be renamed. If specified, the upload process will try first to find resource with actual **Name** and update it. If not found it would try to find one with **RenamedFrom** name and update it, including rename to actual name. Only if none of the resources are found, a new one will be created. Default value: **null**. |
|**Description**|String|Resource description. Default value: **null**. |
|**ContentType**|VariableSetContentType|Variable set type. Possible values: **Variables**, **ScriptModule**. Default value: **Variables**. |
|**Variables**|[YamlVariable](#YamlVariable)\[\]|List of variables. Default value: **null**. |

### <a name="YamlLifecycle"></a>11. YamlLifecycle

Lifecycle model definition.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Unique name. It can be used in other models to refer to this item. Default value: **null**. |
|**RenamedFrom**|String|Indicates that resource should be renamed. If specified, the upload process will try first to find resource with actual **Name** and update it. If not found it would try to find one with **RenamedFrom** name and update it, including rename to actual name. Only if none of the resources are found, a new one will be created. Default value: **null**. |
|**Description**|String|Lifecycle resource description. Default value: **null**. |
|**TentacleRetentionPolicy**|[YamlRetentionPolicy](#YamlRetentionPolicy)|Tentacle retention policy, defining how long deployments are being kept on machines. Default value: **null**. |
|**ReleaseRetentionPolicy**|[YamlRetentionPolicy](#YamlRetentionPolicy)|Release retention policy, defining how long releases are being kept in Octopus. Default value: **null**. |
|**Phases**|[YamlPhase](#YamlPhase)\[\]|List of deployment phases. Default value: **null**. |

### <a name="YamlNamedElement"></a>12. YamlNamedElement

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Unique name. It can be used in other models to refer to this item. Default value: **null**. |
|**RenamedFrom**|String|Indicates that resource should be renamed. If specified, the upload process will try first to find resource with actual **Name** and update it. If not found it would try to find one with **RenamedFrom** name and update it, including rename to actual name. Only if none of the resources are found, a new one will be created. Default value: **null**. |

### <a name="YamlOctopusModel"></a>13. YamlOctopusModel

Octopus model root type.

|Property|Type|Description|
|--------|----|:----------|
|**ProjectGroups**|[YamlProjectGroup](#YamlProjectGroup)\[\]|List of Project Groups. Default value: **null**. |
|**Projects**|[YamlProject](#YamlProject)\[\]|List of Projects. Default value: **null**. |
|**Lifecycles**|[YamlLifecycle](#YamlLifecycle)\[\]|List of Lifecycles. Default value: **null**. |
|**LibraryVariableSets**|[YamlLibraryVariableSet](#YamlLibraryVariableSet)\[\]|List of Library Variable Sets (including Script modules). Default value: **null**. |
|**Templates**|[YamlTemplates](#YamlTemplates)|Templates node allowing to define templates for other octopus model elements. Default value: **null**. |

### <a name="YamlPhase"></a>14. YamlPhase

Lifecycle deployment Phase definition.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Unique name. It can be used in other models to refer to this item. Default value: **null**. |
|**RenamedFrom**|String|Indicates that resource should be renamed. If specified, the upload process will try first to find resource with actual **Name** and update it. If not found it would try to find one with **RenamedFrom** name and update it, including rename to actual name. Only if none of the resources are found, a new one will be created. Default value: **null**. |
|**MinimumEnvironmentsBeforePromotion**|Int32|Number of environments where release has to be deployed in order to proceed to next phase, where **0** means **all**. Default value: **0**. |
|**TentacleRetentionPolicy**|[YamlRetentionPolicy](#YamlRetentionPolicy)|Tentacle retention policy, defining how long deployments are being kept on machines. If ReleaseRetentionPolicy and TentacleRetentionPolicy are not specified in this resource, the Lifecycle retention policies are used. Default value: **null**. |
|**ReleaseRetentionPolicy**|[YamlRetentionPolicy](#YamlRetentionPolicy)|Release retention policy, defining how long releases are being kept in Octopus. If ReleaseRetentionPolicy and TentacleRetentionPolicy are not specified in this resource, the Lifecycle retention policies are used. Default value: **null**. |
|**AutomaticDeploymentTargetRefs**|String\[\]|List of environment references (based on name) where release is automatically deployed to. Default value: **null**. |
|**OptionalDeploymentTargetRefs**|String\[\]|List of environment references (based on name) where release is manually deployed to. Default value: **null**. |

### <a name="YamlProject"></a>15. YamlProject

Octopus Project model.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Unique name. It can be used in other models to refer to this item. Default value: **null**. |
|**RenamedFrom**|String|Indicates that resource should be renamed. If specified, the upload process will try first to find resource with actual **Name** and update it. If not found it would try to find one with **RenamedFrom** name and update it, including rename to actual name. Only if none of the resources are found, a new one will be created. Default value: **null**. |
|**UseTemplate**|[YamlTemplateReference](#YamlTemplateReference)|Indicates that the resource is template based. Default value: **null**. |
|**Description**|String|Project description. Default value: **null**. |
|**LifecycleRef**|String|Lifecycle reference. Default value: **null**. |
|**ProjectGroupRef**|String|Project Group reference. Default value: **null**. |
|**IncludedLibraryVariableSetRefs**|String\[\]|References of Library Variable Sets that should be included in the project. Default value: **null**. |
|**IsDisabled**|Boolean|Disable a project to prevent releases or deployments from being created. Default value: **False**. |
|**AutoCreateRelease**|Boolean| Default value: **False**. |
|**DefaultToSkipIfAlreadyInstalled**|Boolean|Skips package deployment and installation if it is already installed. Default value: **False**. |
|**DeploymentProcess**|[YamlDeploymentProcess](#YamlDeploymentProcess)|Deployment process definition. Default value: **null**. |
|**Variables**|[YamlVariable](#YamlVariable)\[\]|Project variables. Default value: **null**. |

### <a name="YamlProjectGroup"></a>16. YamlProjectGroup

Project Group model.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Unique name. It can be used in other models to refer to this item. Default value: **null**. |
|**RenamedFrom**|String|Indicates that resource should be renamed. If specified, the upload process will try first to find resource with actual **Name** and update it. If not found it would try to find one with **RenamedFrom** name and update it, including rename to actual name. Only if none of the resources are found, a new one will be created. Default value: **null**. |
|**Description**|String|Resource description. Default value: **null**. |

### <a name="YamlPropertyValue"></a>17. YamlPropertyValue

Property Value definition.

|Property|Type|Description|
|--------|----|:----------|
|**Key**|String|Unique property key. Default value: **null**. |
|**Value**|String|Property value. Default value: **null**. |
|**IsSensitive**|Boolean|Should Octopus store this property value in encrypted format? \(Please note that at this moment the sensitive values have to be stored in plain text in yaml definition.\) Default value: **False**. |

### <a name="YamlRetentionPolicy"></a>18. YamlRetentionPolicy

Retention policy definition.

|Property|Type|Description|
|--------|----|:----------|
|**QuantityToKeep**|Int32|Quantity to keep, where 0 means **all**. Default value: **0**. |
|**Unit**|RetentionUnit|Retention unit type. Possible values: **Days**, **Items**. Default value: **Days**. |

### <a name="YamlVariable"></a>19. YamlVariable

Variable definition.

|Property|Type|Description|
|--------|----|:----------|
|**Name**|String|Variable name. Default value: **null**. |
|**Value**|String|Variable value. \(Please note that OctopusProjectBuilder is not able to retrieve values of sensitive variables from Octopus\) Default value: **null**. |
|**IsSensitive**|Boolean|Should Octopus store this variable in encrypted format? \(Please note that at this moment the sensitive values have to be stored in plain text in yaml definition.\) Default value: **False**. |
|**IsEditable**|Boolean| Default value: **True**. |
|**Scope**|[YamlVariableScope](#YamlVariableScope)|Variable scope, including roles, machines, environments, channels and actions. If none specified, variable will be always available in given context. Default value: **null**. |
|**Prompt**|[YamlVariablePrompt](#YamlVariablePrompt)| Default value: **null**. |

### <a name="YamlVariablePrompt"></a>20. YamlVariablePrompt

|Property|Type|Description|
|--------|----|:----------|
|**Label**|String| Default value: **null**. |
|**Description**|String| Default value: **null**. |
|**Required**|Boolean| Default value: **False**. |

### <a name="YamlVariableScope"></a>21. YamlVariableScope

Variable scope definition. It can limit variable visibility to specific context. 
The variable scope should be understand as `(role1 OR ...roleN) AND (machine1 OR ...machineN) AND (env1 OR envN) AND...` where if none resource references are defined of specific type \(like role or machine etc.\) then variable is available to all the resources of that type.

|Property|Type|Description|
|--------|----|:----------|
|**RoleRefs**|String\[\]|List of Role references (based on the name) where variable is applicable to. The roles correspond to roles that Machines have specified. If none are specified, then variable is available to all of them. Default value: **null**. |
|**MachineRefs**|String\[\]|List of Machine references (based on the name) where variable is applicable to. If none are specified, then variable is available to all of them. Default value: **null**. |
|**EnvironmentRefs**|String\[\]|List of Environment references (based on the name) where variable is applicable to. If none are specified, then variable is available to all of them. Default value: **null**. |
|**ChannelRefs**|String\[\]|List of Channel references (based on the name) where variable is applicable to. If none are specified, then variable is available to all of them. Default value: **null**. |
|**ActionRefs**|String\[\]|List of Action references (based on the name) where variable is applicable to. If none are specified, then variable is available to all of them. The Action references can be only specified in Project variables (LibraryVariableSets does not support them). Default value: **null**. |

