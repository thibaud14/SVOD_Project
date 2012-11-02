class VideoController < ApplicationController

  def recent(top)
    if top
      @videos = Video.recent(top)
    end
  end

  def recent_all
    if param[:page]
      @videos = Video.all(:order => "created_at ASC").paginate(page: params[:page])
    end
  end

  def rated(top)
    if top
      @videos = Video.rated(top)
    end
  end

  def rated_all
    if params[:page]
      @videos = Video.all(:order => "star_rating_avg ASC").paginate(page: params[:page])
    end
  end

end