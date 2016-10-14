(function () {
    var app = angular.module('todoApp', []);

    app.controller('CreateTaskController', function ($scope, $http) {
        $scope.Message = ("Her poster vi lidt form data");

        $scope.createTask = function (e) {
            var data = getFormData($("#CreateTaskForm"));


            console.log(data);
            $http({
                method: 'POST',
                url: 'api/Task',
                data: data,
                dataType: "json",

            }).success(function mySucces(dataResponse) {
                $scope.mySucces = dataResponse.data;
            }, function myError(dataResponse) {
                $scope.mySucces = dataResponse.statusText;
                console.log(mySucces);
            });

        }

        $scope.tasks = null;


        $scope.getTasks = function () {
            $http({
                method: "GET",
                url: "../api/Category",
                dataType : "json"
            }).then(function (response) {
                
                $scope.tasks = response.data;

                console.log($scope.tasks);
            });
        }
     
        $scope.getTasks();
      
       
 
    });

    app.controller('CreateCategoryController', function ($scope, $http) {
        $scope.Message = ("her er der hygge data");

        $scope.createCategory = function (e) {
            var data = getFormData($("#CreateCatForm"));

            $http({
                method: 'POST',
                url: '../api/Category',
                data: data,
                dataType: "json",
            })
        }
    });

    app.controller('PanelController', function () {
        this.tab = 1;

        this.selectTab = function (setTab) {
            this.tab = setTab;
        };

        this.isSelected = function (checkTab) {
            return this.tab === checkTab;
        };
    });

    app.controller('AppController', function () {
        this.items = tasks;
    });

    app.controller('ReviewController', function () {
        this.review = {};

        this.addReview = function (item) {
            console.log(item);
            item.reviews.push(this.review);

            this.review = {};
        };
    });

    var tasks = [
        {
            description: "You should go to the gym.",
            name: "Gym",
            time: "5 PM",
            canEdit: true,
            done: false,
            reviews: []
        },
        {
            description: "Go see the doctor. You need it badly.",
            name: "Doctor",
            time: "7 PM",
            canEdit: true,
            done: false,
            reviews: []
        }
    ];


    function getFormData($form) {
        var unindexed_array = $form.serializeArray();
        var indexed_array = {};
        console.log(unindexed_array);
        $.map(unindexed_array, function (n, i) {
            indexed_array[n['name']] = n['value'];
        });

        return indexed_array;
    }

    function TaskInfo(item) {
        return item.name + " " + item.description + " " + item.StartTime;
    }
})();
